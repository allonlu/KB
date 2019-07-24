using DapperExtensions.Mapper;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KB.Dapper
{
   public class CustomPluralizedMapper<T>: AutoClassMapper<T> where T : class
    {
        private Dictionary<string, string> _tableNameMapper = new Dictionary<string, string>() {
            { "Article","t_KB_Article" },
            { "Tag","t_KB_Tag" },
            { "ArticleTag","t_KB_ArticlesTagsRelation" },
            { "Category","t_KB_Category" },
        };

        public override void Table(string tableName)
        {
            base.Table(_tableNameMapper[tableName]);
        }
        protected override void AutoMap(Func<Type, PropertyInfo, bool> canMap)
        {

            Type type = typeof(T);
            bool hasDefinedKey = Properties.Any(p => p.KeyType != KeyType.NotAKey);
            PropertyMap keyMap = null;
            foreach (var propertyInfo in type.GetProperties())
            {
                if (Properties.Any(p => p.Name.Equals(propertyInfo.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    continue;
                }

                if ((canMap != null && !canMap(type, propertyInfo)))
                {
                    continue;
                }
                if (IsAssignableToGenericType(propertyInfo.PropertyType,typeof(ICollection<>)) )
                {
                    continue;
                }
                if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    continue;
                }
                PropertyMap map = Map(propertyInfo);
                if (!hasDefinedKey)
                {
                    if (string.Equals(map.PropertyInfo.Name, "id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        keyMap = map;
                    }

                    // if (keyMap == null && map.PropertyInfo.Name.EndsWith("id", true, CultureInfo.InvariantCulture))
                    if (keyMap == null && map.PropertyInfo.Name.EndsWith("id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        keyMap = map;
                    }
                }
            }

            if (keyMap != null)
            {
                keyMap.Key(PropertyTypeKeyTypeMapping.ContainsKey(keyMap.PropertyInfo.PropertyType)
                    ? PropertyTypeKeyTypeMapping[keyMap.PropertyInfo.PropertyType]
                    : KeyType.Assigned);
            }
        }


        protected  bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var givenTypeInfo = givenType.GetTypeInfo();

            if (givenTypeInfo.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            foreach (var interfaceType in givenType.GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenTypeInfo.BaseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
        }

    }
}
