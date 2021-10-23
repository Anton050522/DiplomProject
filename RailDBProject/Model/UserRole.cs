using System.ComponentModel;

namespace RailDBProject.Model
{
    public enum UserRole
    {
        [Description("Неверифицированный пользователь")]
        newUser,
        [Description("Администратор")]
        Administrator,
        [Description("Управление БелЖД")]
        AdministrationSupervisor,
        [Description("Отделение БелЖД")]
        NodeSupervisor,
        [Description("Дистанция пути")]
        LineSupervisor,
        [Description("Центр диагностики БелДЖ")]
        DiagnosticEmploye
    }
}
