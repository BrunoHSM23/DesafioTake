using System;

namespace Integracao
{
    public class DadosRepositorio
    {
        int status { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string data { get; set; }
        public string avatar { get; set; }
        public string erro { get; set; }
        public DadosRepositorio()
        {

        }
        public DadosRepositorio(int status, string nome, string descricao, string data, string avatar, string erro)
        {
            this.status = status;
            this.nome = nome;
            this.descricao = descricao;
            this.data = data;
            this.avatar = avatar;
            this.erro = erro;
        }
    }
}
