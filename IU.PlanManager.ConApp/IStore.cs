using System;
using System.Collections.Generic;

namespace IU.PlanManager.ConApp
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Uid { get; set; }
    }

    /// <summary>
    /// Интерфейс хранилища
    /// </summary>
    public interface IStore<T> where T : class, IEntity
    {
        /// <summary>
        /// Список сущностей
        /// </summary>
        IEnumerable<T> Entities { get; }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Add(T entity);

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="uid">ID сущности</param>
        T Get(Guid uid);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Update(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="uid">ID сущности</param>
        void Delete(Guid uid);

    }
}
