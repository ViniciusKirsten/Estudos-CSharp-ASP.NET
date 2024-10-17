using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{

    internal class DAL <T> where T : class
    {   //Utilizamos o T para determinar um "tipo genérico"
        //"where T : class" assim estamos dizendo que este "T"  vai ser uma classe dentro da nossa aplicação
        protected readonly ScreenSoundContext context;

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
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao) //O "Func< , >" é um tipo que representa uma função que retorna um valor, uma verificação
        {
            return context.Set<T>().FirstOrDefault(condicao); //sendo assim ele vai trazer o primeiro resultado ou o valor padrão
        }
    }
}
