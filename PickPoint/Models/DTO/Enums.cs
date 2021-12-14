namespace PickPoint.Models.DTO
{
    public enum OrderStatus
    {
        /// <summary>
        /// Зарегистрирован
        /// </summary>
        Registered = 1,
        /// <summary>
        /// Принят на складе
        /// </summary>
        Taken = 2,
        /// <summary>
        /// Выдан курьеру
        /// </summary>
        Issued = 3,
        /// <summary>
        /// Доставлен в постамат
        /// </summary>
        DeliveredToPostamat = 4,
        /// <summary>
        /// Доставлен получателю
        /// </summary>
        DeliveredToRecipient = 5,
        /// <summary>
        /// Отменен
        /// </summary>
        Canceled = 6
    }
}
