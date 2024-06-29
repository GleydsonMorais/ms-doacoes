package com.hackathon.br.web.dtos.mapper;

import com.hackathon.br.entity.Doacao;
import com.hackathon.br.web.dtos.DoacaoResponseDTO;
import lombok.AccessLevel;
import lombok.NoArgsConstructor;
import org.modelmapper.ModelMapper;
import com.hackathon.br.web.dtos.DoacaoCreateDTO;

@NoArgsConstructor(access = AccessLevel.PRIVATE)
public class DoacaoMapper {

    public static Doacao toDoacao(DoacaoCreateDTO dto){
        return new ModelMapper().map(dto, Doacao.class);
    }

    public static DoacaoResponseDTO toDto(Doacao doacao) {
        return new ModelMapper().map(doacao, DoacaoResponseDTO.class);
    }

}
