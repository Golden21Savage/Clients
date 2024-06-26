using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

class Program
{
    class Client
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string НомерТелефона { get; set; }
        public string НомерПаспорта {  get; set; }
        public DateTime ПокупкаДата { get; set; }
        public string Status { get; set; }
    }
    static List<Client> clients = new List<Client>();

    static void Main()
    {
        AddClient(new Client
        {
            Id = 1,
            Имя = "Фаррух",
            Фамилия = "Мирзомансуров",
            НомерТелефона = "+992 927700631",
            НомерПаспорта = "AA1111111",
            ПокупкаДата = DateTime.Now.AddDays(-10),
            Status = "редкий"
        });

        UpdateClientStatus();

        var filteredClients = FilterClientsByName("Фаррух");
        foreach (var client in filteredClients)
        {
            Console.WriteLine($"Client: {client.Имя} {client.Фамилия}");
        }
        static void AddClient(Client client)
        {
            if (!clients.Any(c => c.Id == client.Id || c.НомерПаспорта == client.НомерПаспорта))
            {
                clients.Add(client);
                Console.WriteLine("Клиент успешно добавлен.");
            }
            else
            {
                Console.WriteLine("Клиент уже существует.");
            }
        }

        static void UpdateClientStatus()
        {
            foreach (var client in clients)
            {
                var purchasesLastMonth = clients.Count(c => c.ПокупкаДата >= DateTime.Now.AddMonths(-1));
                client.Status = purchasesLastMonth > 3 ? "постоянный" : "редкий";
            }
        }

        static List<Client> FilterClientsByName(string name)
        {
            return clients.Where(c => c.Имя.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                                      c.Фамилия.Equals(name, StringComparison.OrdinalIgnoreCase))
                          .ToList();
        }
    }
}