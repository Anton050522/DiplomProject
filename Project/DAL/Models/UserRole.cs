using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.DAL.Models
{
    public enum UserRole
    {
        [Description("Администратор")]
        Administrator,
        [Description("Руководитель управления дороги")]
        AdministrationSupervisor,
        [Description("Руководитель отделения дороги")]
        NodeSupervisor,
        [Description("Мастер участка дефектоскопии")]
        LineSupervisor
    }
}
