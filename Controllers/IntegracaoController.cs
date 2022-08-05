using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integracao.Models.Entidades;
using Integracao.Repositorios;
using Integracao.Services;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Integracao.Controllers
{
    [ApiController]
    public class IntegracaoController : ControllerBase
    {

        private static List<DadosRepositorio> DadoReposList = new List<DadosRepositorio>();

        [HttpGet("BuscaRepositorio")]
        [Authorize]

        public IActionResult GetById()
        {

            DadoReposList.Clear();

            try
            {
                var client = new RestClient("https://api.github.com/search/repositories?q=org:takenet+language:C%23+created:<2015-01-01&order=asc"); //Busca os repositorios através de API do GitHub
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/vnd.github.v3+json");
                IRestResponse response = client.Execute(request);
                var trataJson = response.Content;

                dynamic retornoJson = JObject.Parse(trataJson); // Transforma Json em Objeto para manipular ele.

                int totalcount = retornoJson.total_count; // Busca a quantidade de registros a percorrer

                for (int contador = 0; contador < totalcount; contador++) // Percorre todos os registros do JSON
                {
                    string nome = retornoJson.items[contador].name; //Nome do Repositorio
                    string descricao = retornoJson.items[contador].description; // Descrição do Repositorio
                    string data = retornoJson.items[contador].created_at; // Data de criação do Repositorio
                    string avatar = retornoJson.items[contador].owner.avatar_url; //Url de imagem (Avatar) do Repositorio

                    DadoReposList.Add(new DadosRepositorio(200, nome, descricao, data, avatar, "")); // Adiciona a lista todos os repositorios encontrados em JSON e retorna em API
                }

                return Ok(DadoReposList);
            }
            catch (Exception)
            {
                DadoReposList.Add(new DadosRepositorio(400,"", "", "", "", "Erro inesperado ocorreu")); // Caso ocorra algum erro durante o processo.

                return BadRequest(DadoReposList);
            }

        }

    }
}