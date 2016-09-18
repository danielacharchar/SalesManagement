using SalesManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Data
{
    public class SalesManagementDbInitializer
    {
        private static SalesManagementContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (SalesManagementContext)serviceProvider.GetService(typeof(SalesManagementContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            if (!context.Users.Any())
            {
                User user_01 = new User { Name = "Chris Sakellarios", Username = "chris", Email = "a@a.com", HashedPassword = "", IsLocked = false };
                User user_02 = new User { Name = "Charlene Campbell", Username = "charlene", Email = "a@a.com", HashedPassword = "", IsLocked = false };
                User user_03 = new User { Name = "Mattie Lyons", Username = "mattie", Email = "a@a.com", HashedPassword = "", IsLocked = false };
                User user_04 = new User { Name = "Kelly Alvarez", Username = "kelly", Email = "a@a.com", HashedPassword = "", IsLocked = false };
                User user_05 = new User { Name = "Charlie Cox", Username = "cox", Email = "a@a.com", HashedPassword = "", IsLocked = false };
                User user_06 = new User { Name = "Megan	Fox", Username = "fox", Email = "a@a.com", HashedPassword = "", IsLocked = false };

                context.Users.Add(user_01); context.Users.Add(user_02);
                context.Users.Add(user_03); context.Users.Add(user_04);
                context.Users.Add(user_05); context.Users.Add(user_06);


                Role role_01 = new Role { Name = "Role 1" };
                Role role_02 = new Role { Name = "Role 2" };
                Role role_03 = new Role { Name = "Role 3" };
                Role role_04 = new Role { Name = "Role 4" };
                Role role_05 = new Role { Name = "Role 5" };
                Role role_06 = new Role { Name = "Role 6" };

                context.Roles.Add(role_01); context.Roles.Add(role_02);
                context.Roles.Add(role_03); context.Roles.Add(role_04);
                context.Roles.Add(role_05); context.Roles.Add(role_06);

                UserRole userRole_01 = new UserRole { Role = role_01, User = user_01 };
                UserRole userRole_02 = new UserRole { Role = role_02, User = user_01 };
                UserRole userRole_03 = new UserRole { Role = role_03, User = user_01 };
                UserRole userRole_04 = new UserRole { Role = role_04, User = user_02 };
                UserRole userRole_05 = new UserRole { Role = role_05, User = user_02 };
                UserRole userRole_06 = new UserRole { Role = role_06, User = user_02 };

                context.UserRoles.Add(userRole_01); context.UserRoles.Add(userRole_02);
                context.UserRoles.Add(userRole_03); context.UserRoles.Add(userRole_04);
                context.UserRoles.Add(userRole_05); context.UserRoles.Add(userRole_05);

                context.SaveChanges();
            }

        }
        //    if (!context.Schedules.Any())
        //    {
        //        Schedule schedule_01 = new Schedule
        //        {
        //            Title = "Meeting",
        //            Description = "Meeting at work with the boss",
        //            Location = "Korai",
        //            CreatorId = 1,
        //            Status = ScheduleStatus.Valid,
        //            Type = ScheduleType.Work,
        //            TimeStart = DateTime.Now.AddHours(4),
        //            TimeEnd = DateTime.Now.AddHours(6),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 1, UserId = 2 },
        //                new Attendee() { ScheduleId = 1, UserId = 3 },
        //                new Attendee() { ScheduleId = 1, UserId = 4 }
        //            }                    
        //        };

        //        Schedule schedule_02 = new Schedule
        //        {
        //            Title = "Coffee",
        //            Description = "Coffee with folks",
        //            Location = "Athens",
        //            CreatorId = 2,
        //            Status = ScheduleStatus.Valid,
        //            Type = ScheduleType.Coffee,
        //            TimeStart = DateTime.Now.AddHours(3),
        //            TimeEnd = DateTime.Now.AddHours(6),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 2, UserId = 1 },
        //                new Attendee() { ScheduleId = 1, UserId = 3 },
        //                new Attendee() { ScheduleId = 2, UserId = 4 }
        //            }
        //        };

        //        Schedule schedule_03 = new Schedule
        //        {
        //            Title = "Shopping day",
        //            Description = "Shopping therapy",
        //            Location = "Attica",
        //            CreatorId = 3,
        //            Status = ScheduleStatus.Valid,
        //            Type = ScheduleType.Shopping,
        //            TimeStart = DateTime.Now.AddHours(3),
        //            TimeEnd = DateTime.Now.AddHours(6),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 3, UserId = 1 },
        //                new Attendee() { ScheduleId = 3, UserId = 4 },
        //                new Attendee() { ScheduleId = 3, UserId = 5 }
        //            }
        //        };

        //        Schedule schedule_04 = new Schedule
        //        {
        //            Title = "Family",
        //            Description = "Thanks giving day",
        //            Location = "Home",
        //            CreatorId = 5,
        //            Status = ScheduleStatus.Valid,
        //            Type = ScheduleType.Other,
        //            TimeStart = DateTime.Now.AddHours(3),
        //            TimeEnd = DateTime.Now.AddHours(6),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 4, UserId = 1 },
        //                new Attendee() { ScheduleId = 4, UserId = 2 },
        //                new Attendee() { ScheduleId = 4, UserId = 5 }
        //            }
        //        };

        //        Schedule schedule_05 = new Schedule
        //        {
        //            Title = "Friends",
        //            Description = "Friends giving day",
        //            Location = "Home",
        //            CreatorId = 5,
        //            Status = ScheduleStatus.Cancelled,
        //            Type = ScheduleType.Other,
        //            TimeStart = DateTime.Now.AddHours(5),
        //            TimeEnd = DateTime.Now.AddHours(7),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 4, UserId = 1 },
        //                new Attendee() { ScheduleId = 4, UserId = 2 },
        //                new Attendee() { ScheduleId = 4, UserId = 3 },
        //                new Attendee() { ScheduleId = 4, UserId = 4 },
        //                new Attendee() { ScheduleId = 4, UserId = 5 }
        //            }
        //        };

        //        Schedule schedule_06 = new Schedule
        //        {
        //            Title = "Meeting with the boss and collegues",
        //            Description = "Discuss project planning",
        //            Location = "Office",
        //            CreatorId = 3,
        //            Status = ScheduleStatus.Cancelled,
        //            Type = ScheduleType.Other,
        //            TimeStart = DateTime.Now.AddHours(22),
        //            TimeEnd = DateTime.Now.AddHours(30),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 4, UserId = 1 },
        //                new Attendee() { ScheduleId = 4, UserId = 2 },
        //                new Attendee() { ScheduleId = 4, UserId = 5 }
        //            }
        //        };

        //        Schedule schedule_07 = new Schedule
        //        {
        //            Title = "Scenario presentation",
        //            Description = "Discuss new movie's scenario",
        //            Location = "My special place",
        //            CreatorId = 6,
        //            Status = ScheduleStatus.Cancelled,
        //            Type = ScheduleType.Other,
        //            TimeStart = DateTime.Now.AddHours(11),
        //            TimeEnd = DateTime.Now.AddHours(13),
        //            Attendees = new List<Attendee>
        //            {
        //                new Attendee() { ScheduleId = 4, UserId = 4 },
        //                new Attendee() { ScheduleId = 4, UserId = 2 },
        //                new Attendee() { ScheduleId = 4, UserId = 3 }
        //            }
        //        };

        //        context.Schedules.Add(schedule_01); context.Schedules.Add(schedule_02);
        //        context.Schedules.Add(schedule_03); context.Schedules.Add(schedule_04);
        //        context.Schedules.Add(schedule_05); context.Schedules.Add(schedule_06);
        //    }

        //    context.SaveChanges();
        //}
    }
}
