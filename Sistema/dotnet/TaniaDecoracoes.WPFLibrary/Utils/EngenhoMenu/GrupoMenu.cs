namespace TaniaDecoracoes.WPFLibrary.Utils.EngenhoMenu
{
    public class GrupoMenu
    {
        private string titulo = "título";
        public string Titulo
        {
            get => titulo;
            set => titulo = value;
        }

        private IEnumerable<ItemMenu> _itens;
        public IEnumerable<ItemMenu> Itens
        {
            get => _itens;
            set => _itens = value;
        }
    }
}
