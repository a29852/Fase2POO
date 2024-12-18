using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Regras;

namespace Principal
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CLIENTE

            Cliente c1 = new Cliente(1, "Joao", 999, 30, "M");
            Cliente c2 = new Cliente(2, "maria", 111, 22, "F");
            Cliente c3 = new Cliente(2, "maria", 111, 22, "F"); //testar se funciona o metodo Equals

           
            try
            {
                RegraCliente.TentaRegistarCliente(c1);
                RegraCliente.TentaRegistarCliente(c2);
                RegraCliente.TentaRegistarCliente(c3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Pesquisar cliente 2");
                Cliente aux = RegraCliente.TentaPequisarCliente(2);
                Console.WriteLine("nome: " + aux.Nome.ToString());
                Console.WriteLine("id: " + aux.Id.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Clientes existentes: ");
                List<Cliente> listaDeClientes = RegraCliente.TentaTodosClientes();

                foreach (Cliente cliente in listaDeClientes)
                {
                    Console.WriteLine($"Id: {cliente.Id}, Nome: {cliente.Nome}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //ALOJAMENTO
            
            Alojamento a1 = new Alojamento(1, "casa", "braga", 12, true);
            Alojamento a2 = new Alojamento(2, "apartamento", "barcelos", 10, true);
            Alojamento a3 = new Alojamento(3, "apartamento", "porto", 10, true);

            try
            {
                RegraAlojamento.TentaRegistarAlojamento(a1);
                RegraAlojamento.TentaRegistarAlojamento(a2);
                RegraAlojamento.TentaRegistarAlojamento(a3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                Console.WriteLine("Pesquisar alojamento 2: ");
                Alojamento aux2 = RegraAlojamento.TentaPequisarAlojamento(2);
                Console.WriteLine("localidade: " + aux2.Localizacao.ToString());
                Console.WriteLine("disponibilidade: " + aux2.Disponivel.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Alojamentos Existentes:");
                List<Alojamento> listaDeAlojamentos = RegraAlojamento.TentaTodosAlojamentos();

                foreach (Alojamento aloj in listaDeAlojamentos)
                {
                    Console.WriteLine($"Número: {aloj.Numero}, Localização: {aloj.Localizacao}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //RESERVA
            DateTime date = new DateTime(2025, 11, 12, 00, 00, 00);
            DateTime date2 = new DateTime(2026, 11, 12, 00, 00, 00);
            Reserva r1 = new Reserva(1, c1.Id, 2, date2);
            Reserva r2 = new Reserva(2, c2.Id, 1, date);

            try
            {
                RegraReserva.TentaRegistarReserva(r1);
                RegraReserva.TentaRegistarReserva(r2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Alojamentos Disponiveis:");
                List<Alojamento> listaDeAlojamentos2 = RegraAlojamento.TentaTodosAlojamentos();

                foreach (Alojamento aloj in listaDeAlojamentos2)
                {
                    if (aloj.Disponivel == true)
                    {
                        Console.WriteLine($"Número: {aloj.Numero}, Localização: {aloj.Localizacao}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


         

            try
            {
                Reserva aux3 = RegraReserva.TentaPequisarReserva(2);
                Console.WriteLine("Cliente: " + aux3.IdCliente.ToString());
                Console.WriteLine("Alojamento: " + aux3.NumAloj.ToString());
                Console.WriteLine("DataFim: " + aux3.DataFim.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           


            RegraReserva.TentaModificarReserva(2, 3);

            try
            {
                Console.WriteLine("Alojamentos Disponiveis: ");
                List<Alojamento> listaDeAlojamentos3 = RegraAlojamento.TentaTodosAlojamentos();

                foreach (Alojamento aloj in listaDeAlojamentos3)
                {
                    if (aloj.Disponivel == true)
                    {
                        Console.WriteLine($"Número: {aloj.Numero}, Localização: {aloj.Localizacao}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                RegraReserva.TentaFazerCheckIn(1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Todas as Reservas: ");
                List<Reserva> listaDeReservas = RegraReserva.TentaTodosReservas();

                foreach (Reserva reserva in listaDeReservas)
                {
                    Console.WriteLine($"Id: {reserva.Id}, IdCliente: {reserva.IdCliente}, NumAloj: {reserva.NumAloj}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                RegraReserva.TentaGuardaReservas("C:\\Temp");
                RegraCliente.TentaGuardaClientes("C:\\Temp");
                RegraAlojamento.TentaGuardaAlojamentos("C:\\Temp");

                RegraReserva.TentaCarregaReservas("C:\\Temp");
                RegraCliente.TentaCarregaClientes("C:\\Temp");
                RegraAlojamento.TentaCarregaAlojamentos("C:\\Temp");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}
