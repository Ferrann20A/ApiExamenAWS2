using ApiExamenAWS2.Data;
using ApiExamenAWS2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAWS2.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return await this.context.Eventos.ToListAsync();
        }

        public async Task<List<CategoriaEvento>> GetCategoriasEventosAsync()
        {
            return await this.context.CategoriasEventos.ToListAsync();
        }

        public async Task<List<Evento>> GetEventosByCategoriaAsync(int idcategoria)
        {
            var consulta = from datos in this.context.Eventos
                           where datos.IdCategoria == idcategoria
                           select datos;
            return await consulta.ToListAsync();
        }
    }
}
