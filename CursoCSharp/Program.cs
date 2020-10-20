using System;
using System.Dynamic;
using System.Globalization;

namespace CursoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            var departamento = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Nível (Junior = 0, Pleno = 1, Senior = 2): ");
            var level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário base: ");
            var salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(departamento);
            var worker = new Worker(nome, level, salario, dept);

            Console.Write("Quantos contratos para este trabalhador: ");
            var n = int.Parse(Console.ReadLine());

            for(int i =0; i<n; i++)
            {
                Console.WriteLine($"Entre com o contrato n° {i}: ");
                Console.Write("Data: (dd/mm/yyyy): ");
                var date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                var valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração em horas: ");
                var horas = int.Parse(Console.ReadLine());

                var contract = new HourContract(date, valorPorHora, horas);

                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular o valor a recebido: ");
            string mesAno = Console.ReadLine();
            var mes = int.Parse(mesAno.Substring(0, 2));
            var ano = int.Parse(mesAno.Substring(3));

            Console.WriteLine($"Nome: {nome}\nDepartamento: {worker.Department.Name}\nTotal recebido para {mesAno}: {worker.Income(ano,mes).ToString("F2", CultureInfo.InvariantCulture)}"); 
        }
    }
}
