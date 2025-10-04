namespace TaniaDecoracoes.WPFLibrary.Utils.EngenhoMenu
{
    public class Menu
    {
        private string _titulo = "Título";
        public string Titulo 
        { 
            get => _titulo; 
            set => _titulo = value;
        }

        private IEnumerable<GrupoMenu> _grupos;
        public IEnumerable<GrupoMenu> Grupos
        {
            get => _grupos;
            set => _grupos = value;
        }
    }
}
