package com.hackathon.br.service;

import com.hackathon.br.entity.Doacao;
import com.hackathon.br.exceptions.ExternalServiceException;
import com.hackathon.br.repository.DoacaoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.*;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


@Service
public class DoacaoService {

    @Autowired
    private DoacaoRepository doacaoRepository;

    @Autowired
    private RestTemplate restTemplate;

    @Value("${hackathon.api.url}")
    private String hackathonApiUrl;

    @Value("${hackathon.api.key}")
    private String apiKey;

    // Método para buscar doações por CPF
    public List<Doacao> buscarDoacoesPorCPF(String cpf) {
        // Verifica na API da MS
        ResponseEntity<List<Doacao>> responseFromApi = buscarDoacoesNaApiExterna(cpf);
        if (responseFromApi.getStatusCode() == HttpStatus.OK) {
            List<Doacao> doacoesFromApi = responseFromApi.getBody();
            if (!doacoesFromApi.isEmpty()) {
                return doacoesFromApi;
            }
        }

        // Caso não encontre na API externa, busca no nosso banco de dados
        return doacaoRepository.findByCpf(cpf);
    }


    public Doacao realizarDoacao(String cpf, BigDecimal valor) {
        Doacao doacao = new Doacao();
        doacao.setCpf(cpf);
        doacao.setValor(valor);
        doacao.setDtaDoacao(LocalDateTime.now());

        enviarDoacaoParaHackathon(cpf, "ms-hackathon", valor);

        return doacaoRepository.save(doacao);
    }

    public List<Doacao> extratoDoacoes(String cpf) {
        return doacaoRepository.findByCpf(cpf);
    }

    // Método para enviar doações para API externa
    private void enviarDoacaoParaHackathon(String cpf, String appName, BigDecimal valor) {
        String url = hackathonApiUrl;
        Map<String, Object> requestBody = new HashMap<>();
        requestBody.put("cpf", cpf);
        requestBody.put("app_name", appName);
        requestBody.put("valor", valor);

        // Realiza o POST para a API externa
        restTemplate.postForObject(url, requestBody, Void.class);
    }

    // Método para buscar doações na API externa
    private ResponseEntity<List<Doacao>> buscarDoacoesNaApiExterna(String cpf, String jwtToken) {
        HttpHeaders headers = new HttpHeaders();
        headers.set("Authorization", "Bearer " + jwtToken);
        headers.set("api-key", apiKey);
        headers.set("HACKATON_UNIESP_MARJO_2024", "true");

        HttpEntity<String> entity = new HttpEntity<>(headers);

        try {
            ResponseEntity<List<Doacao>> response = restTemplate.exchange(
                    hackathonApiUrl + "?cpf=" + cpf,
                    HttpMethod.GET,
                    entity,
                    new ParameterizedTypeReference<List<Doacao>>() {});
            return response;
        } catch (RestClientException e) {
            throw new ExternalServiceException("Erro externo da API.");
        }
    }

}
