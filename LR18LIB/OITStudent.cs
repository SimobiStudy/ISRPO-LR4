using System.Collections;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace LR18LIB
{
    /// <summary>
    /// Класс для хранения данных о студенте отделения ОИТ.
    /// Содержит информацию о номере группы, полном имени, дате рождения и номере телефона.
    /// </summary>
    public class OITStudent : IComparable<OITStudent>
    {
        /// <summary>
        /// Получает или устанавливает номер группы студента.
        /// </summary>
        [DisplayName("Группа")]
        
        public string GroupNumber { get; set; }

        /// <summary>
        /// Получает или устанавливает полное имя студента (фамилия, имя, отчество).
        /// </summary>
        [DisplayName("ФИО")]
        public string Name { get; set; }

        /// <summary>
        /// Получает или устанавливает дату рождения студента.
        /// </summary>
        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Получает или устанавливает номер телефона студента.
        /// </summary>
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        /// <summary>
        /// Получает или устанавливает электронную почту студента.
        /// </summary>
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OITStudent"/> с пустыми значениями.
        /// </summary>
        public OITStudent() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OITStudent"/> с указанными параметрами.
        /// </summary>
        /// <param name="groupNumber">Номер группы студента.</param>
        /// <param name="name">Полное имя студента (фамилия, имя, отчество).</param>
        /// <param name="birthDay">Дата рождения студента.</param>
        /// <param name="phone">Номер телефона студента.</param>
        public OITStudent(string groupNumber, string name, DateTime birthDay, string phone, string email)
        {
            GroupNumber = groupNumber;
            Name = name;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
        }

        public OITStudent(string groupNumber, string name, DateTime birthDay, string phone) : this (groupNumber, name, birthDay, phone, null)
        {
        }

        /// <summary>
        /// Определяет, равны ли два объекта <see cref="OITStudent"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>true, если объекты равны; иначе false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not OITStudent student) return false;

            return student.GroupNumber == GroupNumber && 
                   student.Name == Name && 
                   student.BirthDay == BirthDay && 
                   student.Phone == Phone;
        }

        /// <summary>
        /// Возвращает хеш-код объекта.
        /// </summary>
        /// <returns>Хеш-код, основанный на всех свойствах студента.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(GroupNumber, Name, BirthDay, Phone);
        }

        /// <summary>
        /// Возвращает строковое представление студента.
        /// </summary>
        /// <returns>Строка, содержащая информацию о группе, ФИО, дате рождения и телефоне.</returns>
        public override string ToString()
        {
            return $"Группа: {GroupNumber}, ФИО: {Name}, Дата рождения: {BirthDay:yyyy-MM-dd}, Телефон: {Phone}";
        }

        /// <summary>
        /// Сравнивает текущий объект со скалярным объектом того же типа по полному имени.
        /// </summary>
        /// <param name="other">Объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int CompareTo(OITStudent? other)
        {
            if (other is null) return 1;

            return string.Compare(Name, other.Name);
        }

        /// <summary>
        /// Определяет, равны ли два объекта <see cref="OITStudent"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если объекты равны; иначе false.</returns>
        public static bool operator ==(OITStudent? left, OITStudent? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        /// <summary>
        /// Определяет, не равны ли два объекта <see cref="OITStudent"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если объекты не равны; иначе false.</returns>
        public static bool operator !=(OITStudent? left, OITStudent? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Определяет, меньше ли первый объект второго.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если первый объект меньше второго; иначе false.</returns>
        public static bool operator <(OITStudent? left, OITStudent? right)
        {
            if (left is null || right is null) return false;
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Определяет, больше ли первый объект второго.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если первый объект больше второго; иначе false.</returns>
        public static bool operator >(OITStudent? left, OITStudent? right)
        {
            if (left is null || right is null) return false;
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Определяет, меньше ли или равен первый объект второму.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если первый объект меньше или равен второму; иначе false.</returns>
        public static bool operator <=(OITStudent? left, OITStudent? right)
        {
            if (left is null || right is null) return false;
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Определяет, больше ли или равен первый объект второму.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>true, если первый объект больше или равен второму; иначе false.</returns>
        public static bool operator >=(OITStudent? left, OITStudent? right)
        {
            if (left is null || right is null) return false;
            return left.CompareTo(right) >= 0;
        }
    }

    /// <summary>
    /// Класс для сравнения студентов по номеру группы в порядке возрастания.
    /// </summary>
    public class StudentCompareByGroup : IComparer<OITStudent>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="OITStudent"/> по номеру группы.
        /// </summary>
        /// <param name="x">Первый объект для сравнения.</param>
        /// <param name="y">Второй объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int Compare(OITStudent? x, OITStudent? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return string.Compare(x.GroupNumber, y.GroupNumber, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// Класс для сравнения студентов по дате рождения в порядке возрастания.
    /// </summary>
    public class StudentCompareByBirthDay : IComparer<OITStudent>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="OITStudent"/> по дате рождения.
        /// </summary>
        /// <param name="x">Первый объект для сравнения.</param>
        /// <param name="y">Второй объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int Compare(OITStudent? x, OITStudent? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return x.BirthDay.CompareTo(y.BirthDay);
        }
    }

    /// <summary>
    /// Класс для сравнения студентов по номеру телефона в порядке возрастания.
    /// </summary>
    public class StudentCompareByPhone : IComparer<OITStudent>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="OITStudent"/> по номеру телефона.
        /// </summary>
        /// <param name="x">Первый объект для сравнения.</param>
        /// <param name="y">Второй объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int Compare(OITStudent? x, OITStudent? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return string.Compare(x.Phone, y.Phone, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// Класс для сравнения студентов по полному имени в порядке возрастания.
    /// </summary>
    public class StudentCompareByName : IComparer<OITStudent>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="OITStudent"/> по полному имени.
        /// </summary>
        /// <param name="x">Первый объект для сравнения.</param>
        /// <param name="y">Второй объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int Compare(OITStudent? x, OITStudent? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// Класс для сравнения студентов по возрасту в порядке возрастания.
    /// </summary>
    public class StudentCompareByAge : IComparer<OITStudent>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="OITStudent"/> по возрасту.
        /// </summary>
        /// <param name="x">Первый объект для сравнения.</param>
        /// <param name="y">Второй объект для сравнения.</param>
        /// <returns>Значение, которое указывает относительный порядок сравниваемых объектов.</returns>
        public int Compare(OITStudent? x, OITStudent? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            int ageX = DateTime.Now.Year - x.BirthDay.Year;
            int ageY = DateTime.Now.Year - y.BirthDay.Year;

            return ageX.CompareTo(ageY);
        }
    }
}
