package com.hackathon.br.web.dtos;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class DoacaoResponseDTO {

    private Long id;
    private String app_name;
    private BigDecimal valor;

}
