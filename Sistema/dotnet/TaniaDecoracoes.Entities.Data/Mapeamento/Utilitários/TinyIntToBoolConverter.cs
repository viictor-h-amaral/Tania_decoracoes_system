using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Utilitários
{
    public class TinyIntToBoolConverter : ValueConverter<bool, byte>
    {
        public static Expression<Func<bool, byte>> BoolToTinyInt 
            => (boolean => boolean ? (byte)1 : (byte)0);

        public static Expression<Func<byte, bool>> TinyIntToBool 
            => (tint => tint == 1);

        public TinyIntToBoolConverter() : base(BoolToTinyInt, TinyIntToBool)
        {
        }
    }

    public class NullableTinyIntToBoolConverter : ValueConverter<bool?, byte?>
    {
        public static Expression<Func<bool?, byte?>> NullableBoolToTinyInt
            => (boolean => boolean.HasValue ? (boolean.Value ? (byte?)1 : (byte?)0) : null);

        public static Expression<Func<byte?, bool?>> NullableTinyIntToBool 
            => (tint => tint.HasValue ? tint.Value == 1 : null);

        public NullableTinyIntToBoolConverter() : base(NullableBoolToTinyInt, NullableTinyIntToBool, null)
        {
        }
    }
}