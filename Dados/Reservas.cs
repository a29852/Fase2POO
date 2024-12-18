using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Dados
{
    /// <summary>
    /// A classe Reservas gerencia os dados relacionados as reservas
    /// </summary>
    public class Reservas
    {
        #region ATRIBUTOS

        /// <summary>
        /// Lista de reservas registadas
        /// </summary>
        static List<Reserva> reservas;

        #endregion

        #region CONSTRURORES

        /// <summary>
        /// Construtor static que inicializa a lista de reservas
        /// </summary>
        static Reservas()
        {
            reservas = new List<Reserva>();
        }

        #endregion


        #region METODOS

        /// <summary>
        /// Pesquisa uma reserva pelo seu Id e retorna a Reserva correspondente
        /// </summary>
        /// <param name="id">Id da reserva a ser pesquisada</param>
        /// <returns>Retorna a Reserva correspondente ou null se não encontrar</returns>
        public static Reserva PequisarReserva(int id)
        {
            try
            {
                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Id == id)
                    {
                        return reserva;
                    }
                }
                return null;
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException("400 | Erro: " + ex.Message);
            }
            catch (IOException e)
            {
                throw new IOException("500 | Erro: " + e.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }

        }

        /// <summary>
        /// Modifica uma reserva existente, alterando o alojamento associado à reserva.
        /// </summary>
        /// <param name="idRes">Id da reserva a ser modificada</param>
        /// <param name="num">Número do alojamento original associado à reserva</param>
        /// <param name="a">Novo alojamento a ser associado à reserva</param>
        /// <returns>Retorna true se a reserva foi modificada com sucesso</returns>
        public static bool ModificarReserva(int idRes, int num, Alojamento a)
        {
            Reserva auxReserva = Reservas.PequisarReserva(idRes);

                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Id == auxReserva.Id)   //verifica se a reserva existe
                    {
                        //muda o alojamento que está na reserva
                        Alojamento aux = Alojamentos.PequisarAlojamento(reserva.NumAloj);
                        aux.Disponivel = true;

                        //muda as informaçoes do novo alojamento
                        reserva.NumAloj = a.Numero;
                        a.Disponivel = false;

                        return true;
                    }
                }
            return false;

        }

        /// <summary>
        /// Compara se a reserva já está registado na lista
        /// </summary>
        /// <param name="r">Objeto Reserva a ser comparado</param>
        /// <returns>Retorna true se a reserva já existe na lista</returns>
        public static bool CompararReserva(Reserva r)
        {
            foreach (Reserva reserva in reservas)
            {
                if (r.Equals(reserva))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regista uma nova reserva na lista
        /// </summary>
        /// <param name="r">Reserva a ser registada</param>
        /// <param name="a">Serve para mudar a disponibilidade do alojamento</param>
        /// <returns>Retorna true se o alojamento for registado com sucesso</returns>
        public static bool RegistarReservas(Reserva r, Alojamento a)
        {

            try
            {
                a.Disponivel = false;
                reservas.Add(r);
                return true;
            }
            catch (IOException e)
            {

                throw new IOException("500 | Erro: " + e.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }
        }



        // <summary>
        /// Retorna todas as reservas
        /// </summary>
        /// <returns>Lista de todas as reservas ordenadas</returns>
        public static List<Reserva> TodosReservas()
        {
            try
            {
                reservas.Sort();
                List<Reserva> lista = new List<Reserva>();
                foreach (Reserva r in reservas)
                {
                    lista.Add(new Reserva(r.Id, r.IdCliente, r.NumAloj, r.DataFim));
                }
                return lista;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// A função verifica a chegado do cleinte
        /// </summary>
        /// <param name="reserva">O parametro serve para mudar o estado do CheckIn</param>
        /// <returns></returns>
        public static bool FazerCheckIn(Reserva reserva)
        {
            try
            {
                reserva.CheckIn = true;
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }

        }

        /// <summary>
        /// Guarda os dados das reservas em um ficheiro binário no caminho especificado
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro será guardado</param>
        /// <returns>Retorna true se os dados forem guardados com sucesso</returns>
        public static bool GuardaReservas(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Reservas.bin", FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, reservas);
                stream.Close();
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
           
        }

        /// <summary>
        /// Carrega os dados das reservas a partir de um ficheiro binário no caminho especificado
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro está</param>
        /// <returns>Retorna true se os dados forem carregados com sucesso</returns>
        public static bool CarregaReservas(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Reservas.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                reservas = (List<Reserva>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
               
        }

        #endregion
    }
}
