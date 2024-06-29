package com.hackathon.br.web.controller;

import com.hackathon.br.entity.Doacao;
import com.hackathon.br.service.DoacaoService;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.math.BigDecimal;
import java.util.List;
import java.util.Map;

@Tag(name = "Doacao", description = "Contém todas as operações relativas aos recursos de uma doação.")
@RestController
@RequestMapping("doacao")
public class DoacaoController {

    @Autowired
    private DoacaoService doacaoService;

    @PostMapping("/cadastrar")
    public ResponseEntity<Doacao> realizarDoacao(@RequestBody Map<String, Object> doacaoData) {
        String cpf = (String) doacaoData.get("cpf");
        BigDecimal valor = new BigDecimal(String.valueOf(doacaoData.get("valor")));

        Doacao doacao = doacaoService.realizarDoacao(cpf, valor);
        return ResponseEntity.ok(doacao);
    }

    // Endpoint para buscar extrato de doações por CPF cadastrados na API
    @GetMapping("/buscarDoacoesAPI")
    public ResponseEntity<List<Doacao>> getExtratoDoacoesPorCPF(@RequestParam String cpf) {
        List<Doacao> extratoDoacoes = doacaoService.buscarDoacoesPorCPF(cpf);
        if (extratoDoacoes.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(extratoDoacoes);
        }
    }

    // Endpoint para buscar extrato de doações por CPF na aplicação
    @GetMapping("/buscarDoacoes")
    public ResponseEntity<List<Doacao>> extratoDoacoes(@RequestParam String cpf) {
        List<Doacao> extrato = doacaoService.extratoDoacoes(cpf);

        return ResponseEntity.ok(extrato);
    }
}