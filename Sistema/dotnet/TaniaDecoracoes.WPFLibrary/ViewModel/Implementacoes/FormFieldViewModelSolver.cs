using System.Reflection;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes
{
    public class FormFieldViewModelSolver
    {
        public FormFieldViewModelSolver() { }

        public static IFormFieldViewModel Resolve(PropertyInfo prop, IEntityModel source)
        {
            FormFieldCreator creator;
            object? value = prop.GetValue(source);

            var fieldType = ResolveFormFieldViewModelType(prop.PropertyType);

            switch (fieldType)
            {
                case FieldType.Instance:
                    {
                        creator = GerarInstanceCreator(prop.PropertyType);
                        int? idValue = (value as IEntityModel)?.Id ?? null;

                        return creator.CreateFormField(
                                    new InstanceFormFieldParams(prop, source, idValue)
                                );
                    }

                case FieldType.Generic:
                    {
                        creator = GerarInstanceCreator(prop.PropertyType.GetGenericArguments()[0]);
                        return CreateFieldViewModel(creator, prop, source);
                    }

                case FieldType.Primitive:
                default:
                    {
                        creator = GerarPrimitiveCreator(prop.PropertyType);
                        return creator.CreateFormField(
                                    new PrimitiveFormFieldParams(prop, source)
                                );
                    }
            }
        }

        private static FieldType ResolveFormFieldViewModelType(Type propertyType)
        {
            if (
                    (
                        propertyType.IsPrimitive 
                    ) ||
                    (
                        propertyType.IsGenericType 
                            && 
                        propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ) ||
                    propertyType == typeof(string) ||
                    (
                        propertyType == typeof(decimal) 
                            ||
                        propertyType == typeof(decimal?) 
                            ||
                        propertyType == typeof(DateTime) 
                            ||
                        propertyType == typeof(DateTime?)
                    ) 
                ) 
            {
                return FieldType.Primitive;
            }

            if (typeof(IEntityModel).IsAssignableFrom(propertyType))
            {
                return FieldType.Instance;
            }

            if (propertyType.IsGenericType)
            {
                var genericArgs = propertyType.GetGenericArguments();
                if (genericArgs.Length == 1 && typeof(IEntityModel).IsAssignableFrom(genericArgs[0]))
                {
                    return FieldType.Generic;
                }
            }

            return FieldType.Primitive;
        }

        private static FormFieldCreator GerarInstanceCreator(Type type)
        {
            var genericType = typeof(InstanceFormFieldCreator<>).MakeGenericType(type);
            return (FormFieldCreator)Activator.CreateInstance(genericType)!;
        }

        private static FormFieldCreator GerarPrimitiveCreator(Type type)
        {
            var genericType = typeof(PrimitiveFormFieldCreator<>).MakeGenericType(type);
            return (FormFieldCreator)Activator.CreateInstance(genericType)!;
        }

        private static IFormFieldViewModel CreateFieldViewModel(FormFieldCreator creator, PropertyInfo prop, IEntityModel source)
        {
            object? value = prop.GetValue(source);
            int? idValue = (value as IEntityModel)?.Id ?? null;
            return creator.CreateFormField(new InstanceFormFieldParams(prop, source, idValue));
        }
    }

    public enum FieldType
    {
        Primitive = 1,
        Instance = 2,
        Generic = 4
    }
}
