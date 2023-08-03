namespace ObserverDesignPattern
{
    internal class Program
    {
        public class Employee 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public List<IObserver> observers { get; set; } = new();
            public Employee(int id, string name, int salary)
            {
                Id = id;
                Name = name;
                Salary = salary;
            }
            public void notifyAllObservers() //employeenin maasi deyisdikce observerdeki departmentlere melumat gedir
            {
                foreach (IObserver observer in observers)
                {
                    observer.SendMessage();
                }
            }
        }
        public interface IObserver //observer listine yigilmaq ucun hamisi implement etmelidir
        {
            public void SendMessage();
        }

        public class HumanResourcesObs: IObserver
        {
            public Employee Emp { get; set; }
            public HumanResourcesObs(Employee employee)
            {
                Emp = employee;
                Emp.observers.Add(this);
            }
            public void SendMessage()
            {
                Console.WriteLine($"Human Resources are informed salary is {Emp.Salary}");
            }
        }

        public class HighManagementObs : IObserver
        {
            public Employee Emp { get; set; }
            public HighManagementObs(Employee employee)
            {
                Emp = employee;
                Emp.observers.Add(this);
            }
            public void SendMessage()
            {
                Console.WriteLine($"High Management are informedis {Emp.Salary}");
            }
        }

        static void Main(string[] args)
        {
            Employee emp = new(10, "Siya", 5000);
            new HumanResourcesObs(emp);
            new HighManagementObs(emp);

            emp.Salary = 5200;
            emp.notifyAllObservers();

            Console.WriteLine("");
            Console.WriteLine("");
            emp.Salary = 5500;
            emp.notifyAllObservers();

        }
    }
}