using DDDTreino.Aplicao.Interfaces;
using DDDTreino.Aplicao.Servicos;
using DDDTreino.Dominio.Interfaces.Repositorios;
using DDDTreino.Dominio.Interfaces.Servicos;
using DDDTreino.Dominio.Servicos;
using DDDTreino.Infra.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace DDDTreino.Infra.IoC
{
    public class InjetorDependencias
    {
        public static void Registrar(IServiceCollection svCollection)
        {
            svCollection.AddScoped(typeof(IAppBase<,>), typeof(ServicoAppBase<,>));
            svCollection.AddScoped<ILivroApp, LivroApp>();
            svCollection.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            svCollection.AddScoped<ILivroServico, LivroServico>();
            svCollection.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            svCollection.AddScoped<ILivroRepositorio, LivroRepositorio>();
        }
    }
}
