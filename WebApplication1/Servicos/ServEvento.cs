using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Entidades;
using TP_MS_Evento;
using System.Diagnostics;

namespace Servicos
{
    public interface IServEvento
    {
        void Inserir(InserirEventoDTO inserirEventoDto);
        public void Cancelar(int id, Boolean CancelarEvento);
        List<EntidadeEvento> BuscarTodos();
        public void AtualizaIngressos(AtualizarIngressos atualizarIngressos);
        public List<EntidadeEvento> BuscarMaisVendidos();
        public void BuscarEvento(InserirVendaDTO inserirVendaDto);

    }

    public class ServEvento : IServEvento
    {
        public required DataContext _dataContext;

        public ServEvento(DataContext dataContext)
        {
            _dataContext = dataContext;
         }

        public void Inserir(InserirEventoDTO inserirEventoDto)
        {
            EntidadeEvento evento = new EntidadeEvento()
            {
                Nome = inserirEventoDto.Nome,
                Local = inserirEventoDto.Local,
                Atracao = inserirEventoDto.Atracao,
                ValorIngresso = inserirEventoDto.ValorIngresso,
                QuantidadeIngresso = inserirEventoDto.QuantidadeIngresso

            };
            _dataContext.Add(evento);

            _dataContext.SaveChanges();
        }

        public void Cancelar(int id, Boolean CancelarEvento)
        {
            var eventoExistente = _dataContext.Evento.FirstOrDefault(evento => evento.Id == id);

            eventoExistente.Cancelado = CancelarEvento;

            //_repoVenda.ExtornarVendaEvento(id);

            _dataContext.Update(eventoExistente);

            _dataContext.SaveChanges();
        }
        
        public List<EntidadeEvento> BuscarTodos()
        {
            var eventos = _dataContext.Evento.ToList();

            return eventos;
        }
        public void BuscarEvento(InserirVendaDTO inserirVendaDto)
        {
            try
            {
                var eventos = _dataContext.Evento.FirstOrDefault(evento => evento.Id == inserirVendaDto.EventoId);

                if (eventos == null)
                {
                    throw new Exception("Evento não encontrado");
                }
                if (inserirVendaDto.Quantidade < 1)
                {
                    throw new Exception("Nao foi informada a quantidade de ingressos");
                }
                if (eventos.QuantidadeIngresso < inserirVendaDto.Quantidade)
                {
                    throw new Exception("Quantidade de Ingresso disponivel no evento nao e suficiente");
                }

                var atualizarIngressos = new AtualizarIngressos
                {
                    EventoId = inserirVendaDto.EventoId,
                    Quantidade = inserirVendaDto.Quantidade
                };

                AtualizaIngressos(atualizarIngressos);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o evento: " + ex.Message);
            }
        }
        public void AtualizaIngressos(AtualizarIngressos atualizarIngressos)
        {
            Console.WriteLine("teste");
            var eventoExistente = _dataContext.Evento.FirstOrDefault(evento => evento.Id == atualizarIngressos.EventoId);

            eventoExistente.QuantidadeIngresso -= atualizarIngressos.Quantidade;
            eventoExistente.QuantidadeVendida += atualizarIngressos.Quantidade;

            Console.WriteLine(eventoExistente);

            _dataContext.Update(eventoExistente);

            _dataContext.SaveChanges();
        }

        public List<EntidadeEvento> BuscarMaisVendidos()
        {
            var eventos = _dataContext.Evento.OrderByDescending(evento => evento.QuantidadeVendida).Take(3).ToList();

            return eventos;
        }
    }
}
