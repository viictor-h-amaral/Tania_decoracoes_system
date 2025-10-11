using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos
{
    public class EnderecosMainPageViewModel
    {
        private MenuViewModel _menuVM;
        public MenuViewModel MenuVM
        {
            get => _menuVM;
            set => _menuVM = value;
        }

        public EnderecosMainPageViewModel()
        {
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            var menuVM = new MenuViewModel();
            menuVM.Titulo = "Endereços";
            
            var grupoCadastro = new GrupoViewModel()
            {
                Titulo = "Cadastrar",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Tipo de logradouro"
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Logradouro"
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Bairro"
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Município"
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Estado"
                    }
                }
            };

            var grupoEnderecosClientes = new GrupoViewModel()
            {
                Titulo = "Endereços de clientes",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Cadastrar/consultar endereços"
                    }
                }
            };

            var grupoEnderecosEventos = new GrupoViewModel()
            {
                Titulo = "Endereços de eventos",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Cadastrar/consultar endereços"
                    }
                }
            };

            menuVM.Grupos = new List<GrupoViewModel>()
            {
                grupoCadastro,
                grupoEnderecosClientes,
                grupoEnderecosEventos
            };

            MenuVM = menuVM;
        }
    }
}
