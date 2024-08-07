﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto;

public class TodoTaskDto {

    [DisplayName("id")]
    public string? Id { get; init; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(1)]
    [MaxLength(100)]
    [DisplayName("name")]
    public string Name { get; init; }

    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; init; }

    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Code")]
    public string? Code { get; init; }

    [DisplayName("is_complete")]
    public bool? IsComplete { get; init; }

    [DisplayName("percentage_completed")]
    public int? PercentageCompleted { get; init; }

}

public class UpdateTodoTaskDto {

    [DisplayName("name")]
    public string? Name { get; init; }

    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; init; }

    [DisplayName("percentage_completed")]
    public int? PercentageCompleted { get; init; }

}