 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacione.Data;
using Estacione.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacione.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly ApplicationDataContext _applicationDataContext;

        public EstacionamentoController(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Lista()
        {
            var listaEstacionamentos = await _applicationDataContext.Estacionamentos.ToListAsync();

            return View(listaEstacionamentos);

        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View("Index");
        }

        public IActionResult Editar(int Id)
        {
            var existeCadastrado = _applicationDataContext.Estacionamentos.Where(x => x.Id == Id).FirstOrDefault();

            return View(existeCadastrado);
        }

        public async Task<IActionResult> CadastrarEstacionamento(Estacionamento estacionamentoJaCadastrado)
        {
            var estacionamentoExiste = await _applicationDataContext.Estacionamentos.AnyAsync(x => x.Cep == estacionamentoJaCadastrado.Cep && x.Numero == estacionamentoJaCadastrado.Numero);

            if(estacionamentoExiste == true)
            {
                return BadRequest("Estacionamento já cadastrado");
            }

            var salvarEstacionamento = new Estacionamento()
            {
                NomeEstacionamento = estacionamentoJaCadastrado.NomeEstacionamento,
                Descricao = estacionamentoJaCadastrado.Descricao,
                PrecoHora = estacionamentoJaCadastrado.PrecoHora,
                Avaliacao = estacionamentoJaCadastrado.Avaliacao,
                NumeroVagas = estacionamentoJaCadastrado.NumeroVagas,
                NomeRua = estacionamentoJaCadastrado.NomeRua,
                Numero = estacionamentoJaCadastrado.Numero,
                Cep = estacionamentoJaCadastrado.Cep,
                Bairro = estacionamentoJaCadastrado.Bairro,
                Cidade = estacionamentoJaCadastrado.Cidade,
                Estado = estacionamentoJaCadastrado.Estado,
                TipoLogradouro = estacionamentoJaCadastrado.TipoLogradouro

            };

            await _applicationDataContext.Estacionamentos.AddAsync(salvarEstacionamento);

            await _applicationDataContext.SaveChangesAsync();

            return RedirectToAction("Index", "Estacionamento");

        }

        public async Task<IActionResult> DeletarEstacionamento(int Id)
        {
            var existeCadastrado = await _applicationDataContext.Estacionamentos.FirstOrDefaultAsync(x => x.Id == Id);

            _applicationDataContext.Estacionamentos.Remove(existeCadastrado);

            await _applicationDataContext.SaveChangesAsync();

            return RedirectToAction("Lista", "Estacionamento");
        }
        public async Task<IActionResult> EditarEstacionamento(Estacionamento estacionamento)
        {
            var existeCadastrado = await _applicationDataContext.Estacionamentos.FirstOrDefaultAsync(x => x.Id == estacionamento.Id); ;


            if (existeCadastrado != null)
            {
                existeCadastrado.NomeEstacionamento = estacionamento.NomeEstacionamento;
                existeCadastrado.Descricao = estacionamento.Descricao;
                existeCadastrado.PrecoHora = estacionamento.PrecoHora;
                existeCadastrado.Avaliacao = estacionamento.Avaliacao;
                existeCadastrado.NumeroVagas = estacionamento.NumeroVagas;
                existeCadastrado.NomeRua = estacionamento.NomeRua;
                existeCadastrado.Numero = estacionamento.Numero;
                existeCadastrado.Cep = estacionamento.Cep;
                existeCadastrado.Bairro = estacionamento.Bairro;
                existeCadastrado.Cidade = estacionamento.Cidade;
                existeCadastrado.Estado = estacionamento.Estado;
                existeCadastrado.TipoLogradouro = estacionamento.TipoLogradouro;

                await _applicationDataContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Estacionamento");
        }
    }
}