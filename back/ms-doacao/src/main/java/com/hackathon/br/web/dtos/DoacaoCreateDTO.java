package com.hackathon.br.web.dtos;


import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.hibernate.validator.constraints.br.CPF;

import java.math.BigDecimal;

@Data @NoArgsConstructor @AllArgsConstructor
public class DoacaoCreateDTO {

    @CPF
    @Size(min = 11, max = 11)
    private String cpf;

    private String app_name;

    private BigDecimal valor;
}
