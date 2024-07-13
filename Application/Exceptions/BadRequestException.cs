namespace Application.Exceptions;

public abstract class BadRequestException(String message) : Exception(message);