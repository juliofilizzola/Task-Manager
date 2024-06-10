using Domain.Utils;
using Domain.Validation;

namespace Domain.Entity;

public class TodoTask : Base {
    public string Name { get; set; }
    public string Code { get; set; }
    public string? SubName { get; set; }
    public bool IsComplete { get; set; } = false;
    private int PercentageCompleted { get; set; } = 0;


    public TodoTask(string name, string? subName, int percentageCompleted) {
        ValidateDomain(name);
        Name = name;
        SubName = subName;
        PercentageCompleted = ValidatePercentage(percentage: percentageCompleted);
        Code = Ramdom.RandomStringCode(6);
        if (PercentageCompleted == 100){
            IsComplete = true;
        }
    }

    public void Update(string name, string code, string? subName, int percentageCompleted) {
        ValidateDomain(name);
        Name = name;
        SubName = subName;
        Code = code;
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