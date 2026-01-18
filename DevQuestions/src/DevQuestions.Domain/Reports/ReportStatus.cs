namespace DirectoryService.Domain.Reports
{
    public enum ReportStatus
    {
        /// <summary>
        /// Статус открыт.
        /// </summary>
        Open,

        /// <summary>
        /// Статус в обработке.
        /// </summary>
        InProgress,

        /// <summary>
        /// Статус решен.
        /// </summary>
        Resolved,

        /// <summary>
        /// Статус закрыт.
        /// </summary>
        Dismissed,
    }
}