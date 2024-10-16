using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class MusicaDAL
    {
        
        private readonly ScreenSoundContext context;
        public MusicaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Musica> listar()
        {
            return context.Musica.ToList();
        }
        //TRABALHANDO NESTA CLASSE
        public void Adicionar(Artista artista)
        {
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        public void Atualizar(Artista artista)
        {
            context.Artistas.Update(artista);
            context.SaveChanges();
        }

        public void Deletar(Artista artista)
        {
            context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
