package com.hackathon.br.repository;

import com.hackathon.br.entity.Doacao;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface DoacaoRepository extends JpaRepository<Doacao, Long> {
    List<Doacao> findByCpf(String cpf);
}
