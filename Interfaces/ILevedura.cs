using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Interfaces
{
    public interface ILevedura
    {
        string Nome { get; set; }
        string Tipo { get; set; } //fazer enum  {lager, ale, kveik}
        string Atenuacao { get; set; } //fazer enum  {baixa, media, alta}
        string Floculacao { get; set; } //fazer enum  {baixa, media, alta}

    }
}
