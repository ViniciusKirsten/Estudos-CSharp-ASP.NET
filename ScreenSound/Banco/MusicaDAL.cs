using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    //"MusicaDAL" herda da classe "DAL", que é um genérico.
    internal class MusicaDAL : DAL <Musica> // "Musica" se refere ao campo T que é um tipo genérico no meu DAL.
    {
        public MusicaDAL(ScreenSoundContext context) : base(context) { } //"base(contex)" representa que ele vai pegar a informação da nossa classe DAL
       
        public  IEnumerable<Musica> Listar()
        {
            return context.Musicas.ToList();
        }

        public void Adicionar(Musica musica){}

        public override void Atualizar(Musica musica)
        {
            context.Musicas.Update(musica);
            context.SaveChanges();
        }

        public override void Deletar(Musica musica)
        {
            context.Musicas.Remove(musica);
            context.SaveChanges();
        }

        public Musica? RecuperarPeloNome(string nome)
        {
            return context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}
