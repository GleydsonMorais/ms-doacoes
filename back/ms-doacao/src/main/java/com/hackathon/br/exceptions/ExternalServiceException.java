package com.hackathon.br.exceptions;

public class ExternalServiceException extends RuntimeException{

    public ExternalServiceException(String message) {
        super(message);
    }

}