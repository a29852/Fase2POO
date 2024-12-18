using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Representa uma pessoa com atributos básicos como a idade e o sexo
    /// </summary>
    [Serializable]
    public class Pessoa
    {
        #region ATRIBUTOS

        /// <summary>
        /// Atributos da classe Pessoa
        /// </summary>

        int idade;
        string sexo;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa uma nova instância de Pessoa
        /// </summary>
        public Pessoa()
        {
            idade = 0;
            sexo = "";
        }

        #endregion

        #region PROPRIEDADES

        // <summary>
        /// Obtém ou define a idade da pessoa
        /// </summary>
        public int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                idade = value;
            }
        }

        /// <summary>
        /// Obtém ou define o sexo da pessoa
        /// </summary>
        public string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        #endregion
    }
}
