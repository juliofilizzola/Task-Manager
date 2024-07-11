using Domain.Validation;

namespace Domain.Entity;

public class TodoTask : Base {
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; } = false;
    public int PercentageCompleted { get; set; } = 0;
    public TodoTask( string name, int percentageCompleted, string? description) {
        var newCode = Utils.RandomGenerator.RandomStringCode(6);
        ValidateDomain(name);
        Id = Utils.RandomGenerator.RandomStringCode(34);
        Code = newCode;
        Name = name;
        Description = description;
        PercentageCompleted = ValidatePercentage(percentage: percentageCompleted);
        if (String.IsNullOrEmpty(Code)){
            Code = newCode;
        }
        if (PercentageCompleted == 100){
            IsComplete = true;
        }
    }

    public void Update(string name, int percentageCompleted, string? description) {
        ValidateDomain(name);
        Name = name;
        Description = description;
        PercentageCompleted = percentageCompleted;
    }

    private void ValidateDomain(string name) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid, Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short, minimum 3 characters");
    }

    private int ValidatePercentage(int percentage) {
        return percentage switch {
            < 0   => 0,
            > 100 => 100,
            _     => percentage
        };

    }
}