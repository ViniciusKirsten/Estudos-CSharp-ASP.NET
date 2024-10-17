using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    //Abstract pois eu não vou utilizar nenhum obejto dentro dessa classe
    internal abstract class DAL <T> where T : class
    {   //Utilizamos o T para determinar um "tipo genérico"
        //"where T : class" assim estamos dizendo que este "T"  vai ser uma classe dentro da nossa aplicação
        private readonly ScreenSoundContext context;

        protected DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public  IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();//"Set<T>()" é um recurso do Entity Framework que ajuda a pegar qual o tipo que estamos utilizando
        }
        public void Adicionar(T objeto) 
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public abstract void Atualizar(T objeto);
        public abstract void Deletar(T objeto);
    }
}
