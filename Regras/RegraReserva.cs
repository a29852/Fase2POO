using BO;
using Dados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Regras
{
    /// <summary>
    /// Classe responsável por fornecer as regras de negócio
    /// Contém métodos que interagem com a camada de dados para gerir as reservas
    /// </summary>
    public class RegraReserva
    {
        /// <summary>
        /// Tenta modificar uma reserva existente, alterando o alojamento associado à reserva identificada pelo Id fornecido
        /// </summary>
        /// <param name="idRes">O id da reserva que será modificada</param>
        /// <param name="num">O numero do novo alojamento a ser associado à reserva</param>
        /// <returns>Retorna true se a reserva for modificada com sucesso</returns>
        public static bool TentaModificarReserva(int idRes, int num)
        {
            Alojamento aux2 = Alojamentos.PequisarAlojamento(num);

            if (aux2.Disponivel == true)
            {
                return Reservas.ModificarReserva(idRes, num, aux2);
            }
            return false;

        }

        /// <summary>
        /// Tenta registar uma nova reserva no sistema, verificando se ela já existe
        /// </summary>
        /// <param name="r">A reserva a ser registada</param>
        /// <returns>Retorna true se a reserva foi registado com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static bool TentaRegistarReserva(Reserva r)
        {
            int numero = r.NumAloj;
            Alojamento aux = Alojamentos.PequisarAlojamento(numero);
            try
            {
                if (!Reservas.CompararReserva(r))
                {
                    Reservas.RegistarReservas(r, aux);
                    return true;
                }
                return false;
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
        /// Tenta pesquisar uma reserva pelo id
        /// </summary>
        /// <param name="id">O id da reserva a ser pesquisado</param>
        /// <returns>Retorna a reserva encontrado</returns>
        /// <exception cref="ArgumentException">Lançada se o id da reserva for inválido</exception>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="ApplicationException">Lançada quando ocorre um erro genérico</exception>
        public static Reserva TentaPequisarReserva(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Reservas.PequisarReserva(id);
                }
                throw new ArgumentException("400");
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException("400 | Erro: " + ex.Message);
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
        /// Tenta obter todas as reservas
        /// </summary>
        /// <returns>Retorna uma lista de todas as reservas</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static List<Reserva> TentaTodosReservas()
        {
            try
            {
                return Reservas.TodosReservas();

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
        /// Tenta realizar o checkin para a reserva identificada pelo Id fornecido
        /// </summary>
        /// <param name="id">O id da reserva para a qual o checkin será realizado</param>
        /// <returns>Retorna true se o checkin foi realizado com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static bool TentaFazerCheckIn(int id)
        {
            try
            {
                Reserva reserva = Reservas.PequisarReserva(id);
                if (reserva != null)
                {
                    return Reservas.FazerCheckIn(reserva);
                }
                return false;
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
        /// Tenta guardar todas as reservas em uma pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde as reservas serão guradadas</param>
        /// <returns>Retorna true se as reservas forem salvas com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaGuardaReservas(string pasta)
        {
            try
            {
                return Reservas.GuardaReservas(pasta);

            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta carregar as reservas a partir de um ficheiro binário localizado na pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde o ficheiro de reservas está localizado</param>
        /// <returns>Retorna true se as reservas forem carregadas com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaCarregaReservas(string pasta)
        {
            try
            {
                if (File.Exists(pasta + "\\Reservas.bin"))
                {
                    return Reservas.CarregaReservas(pasta);
                }
                return false;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
          
        }
    }
}
