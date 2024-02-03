using System.Collections.Generic;
using ConsoleApp35;

#region Task 2
List<Exam> exams = new() {
    new Exam { Subject = "Math", Date = new DateTime(2024, 7, 4) },
    new Exam { Subject = "Science", Date = new DateTime(2024, 8, 12) },
    new Exam { Subject = "History", Date = new DateTime(2024, 3, 25) }
};

Show(exams, (x) => !String.IsNullOrWhiteSpace(x.Subject) && x.Subject.StartsWith("A"));
Show(exams, (x) => x.Date < DateTime.Now.Date);
Show(exams, (x) => DateTime.Now.Date < x.Date && x.Date < DateTime.Now.Date.AddMonths(1));
Show(exams, (x) => x.Date.Hour == 8 && x.Date.Minute == 0);



static void Show(List<Exam> exams, Predicate<Exam> predicate) {
    foreach (var exam in exams) {
        if (predicate(exam))
            Console.WriteLine(exam.Subject);
    }
}

exams.RemoveAll((x) => x.Date < DateTime.Now.Date);

bool flag = false;
foreach (var exam in exams) {
    if (exam.Subject == "Math") {
        Console.WriteLine(exam.Subject);
        flag = true;
        break;
    }
    if (flag)
        Console.WriteLine("The list contains Math");
    else
        Console.WriteLine("The list does not contain Math");
}

foreach (var exam in exams) {
    if (exam.Subject == "Math") {
        Console.WriteLine(exam.Subject);
        break;
    }
}

#endregion

#region Task 3

string? option;

do {
    ShowMenu();
    option = Console.ReadLine();

    switch (option) {
        case "1":
            AddExam(exams);
            break;
        case "2":
            RemovePassedExams(exams);
            break;
        case "3":
            ShowPassedExams(exams);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "0");

static void AddExam(List<Exam> exams) {
    do {
        Console.WriteLine("Enter the subject:");
        string subject = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(subject)) {
            Console.WriteLine("Subject cannot be empty");
            continue;
        }

        Console.WriteLine("Enter the date (yyyy-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) {
            Console.WriteLine("Invalid date");
            continue;
        }

        exams.Add(new Exam { Subject = subject, Date = date });
        break;
    } while (true);
}

static void RemovePassedExams(List<Exam> exams) {
    exams.RemoveAll((x) => x.Date < DateTime.Now.Date);
}

static void ShowPassedExams(List<Exam> exams) {
    Show(exams, (x) => x.Date < DateTime.Now.Date);
}

static void ShowMenu() {
    Console.WriteLine();
    Console.WriteLine("1. Add an exam");
    Console.WriteLine("2. Remove passed exams");
    Console.WriteLine("3. Show passed exams");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
}


#endregion