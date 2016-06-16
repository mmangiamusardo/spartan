using System.Collections.Generic;
using System.Data.Entity;
using Spartan.Domain;
using System.Linq;

namespace Spartan.Data
{
    public class SpartanInitializer : DropCreateDatabaseIfModelChanges<SpartanEntitiesContext>
    {
        protected override void Seed(SpartanEntitiesContext context)
        {
            GetClasses().ToList().ForEach(c => context.Classes.Add(c));
            GetGyms().ToList().ForEach(g => context.Gyms.Add(g));

            // why this?
            context.Commit();
            //base.Seed(context);
        }

        public static List<Class> GetClasses()
        {
            return new List<Class>
            {
                new Class
                {
                    Name = "14.30",
                    ClassType = GetClassTypes().Find(n => n.Name == "WOD"),
                    
                }
            };
        }

        public static IQueryable<Gym> GetGyms()
        {
            var gyms = new List<Gym>();

            gyms.Add(new Gym
            {
                Id = 1,
                Name = "CrossFit Box 1",
                GymType = GetGymTypes().Find(g => g.Name == "CrossFit Box")
            });

            gyms.Add(new Gym
            {
                Id = 2,
                Name = "Personal Box 1",
                GymType = GetGymTypes().Find(g => g.Name == "Personal")
            });

            return gyms.AsQueryable();
        }

        public static List<GymType> GetGymTypes()
        {
            return new List<GymType>
            {
                new GymType
                {
                    Id = 1,
                    Name = "CrossFit Box"
                },
                new GymType
                {
                    Id = 2,
                    Name = "Generic Gym"
                },
                new GymType
                {
                    Id = 3,
                    Name = "Martial Arts"
                },
                new GymType
                {
                    Id = 4,
                    Name = "Personal"
                }

            };
        }

        public static List<ClassType> GetClassTypes()
        {
            return new List<ClassType>
            {
                new ClassType
                {
                    Name = "WOD",
                    Order = 1,
                    ShortDescription = "Regular CrossFit class",
                    LongDescription = "A blend of strength, cardio and gymnastic elements in a mix of patterns for time, reps or rounds. A one hour class with a warm up, focus section, WOD and cool down."
                },
                new ClassType
                {
                    Name = "Open Gym",
                    Order = 2,
                    ShortDescription = "Open session",
                    LongDescription = "For more advanced members to practice and lift at their own pace. A coach is still on hand to provide advice and assistance"
                },
                new ClassType
                {
                    Name = "Olympic Lifting",
                    Order = 3,
                    ShortDescription = "Clean & Jerk and Snatch",
                    LongDescription = "A  class dedicated entirely to the Olympic lifts and their associated exercises. We plan periodised blocks of training to ensure your constant improvement"
                },
                new ClassType
                {
                    Name = "Kid",
                    ShortDescription = "",
                    Order = 4,
                    LongDescription = "CrossFit classes especially for kids! With small groups of children in two age bands and fully certified CrossFit Kids instructors we will start them early into the ways of functional fitness. Kids (7-10), Teens (11-14)CrossFit classes especially for kids! With small groups of children in two age bands and fully certified CrossFit Kids instructors we will start them early into the ways of functional fitness. Kids (7-10), Teens (11-14)"
                },
                new ClassType
                {
                    Name = "Mobility",
                    ShortDescription = "",
                    LongDescription = "A class that will unglue your sticky bits and allow you to move like a supple leopard. A whole hour of stretching, mobilising and loosening that will allow you to move with improved function and perform better when you lift. Note - you may need more than one class!"
                },
                new ClassType
                {
                    Name = "Barbell Club",
                    ShortDescription = "",
                    LongDescription = "The Connect Barbell Club runs five sessions a week and devotes the entire hours class to lifting. We focus on the main power lifts such as the Squat, Press, Deadlift and Bench and their accessory exercises. Perfect for those who want to CrossFit but are still focused on getting bigger and stronger.",
                },
                new ClassType
                {
                    Name = "Gymnastics",
                    ShortDescription = "",
                    LongDescription = "This class focusses on gymnastic skills such as Handstands, Ring work, Ropes and Pull ups. We work through both strength and skill sections to develop your bodyweight techniques"
                },
                new ClassType
                {
                    Name = "Competitors",
                    ShortDescription = "",
                    LongDescription ="There are now CrossFit competitions throughout the country during most months of the year and as we have grown at Connect we have developed and coached some very good athletes who now participate in these events.This is an advanced class for those members really looking to push their training to the next level and compete against the best CrossFitters in the country"
                },
                new ClassType
                {
                    Name = "Focus"
                }
            };
        }
    
        public static ApplicationUser GetUser()
        {
            return new ApplicationUser()
            {
                //Id = "f2de7012-5411-4e33-b4c5-abdc54662715",
                Email = "test@test.com",
                EmailConfirmed = false,
                PasswordHash = "ADpKjrhBepfLbKeyQL+ouSHn6YdM6A2htPIT3WFas/C+OD0HrrZWX+TCQt5kuydzfw==",
                SecurityStamp = "80ff829e-af8b-4031-bba0-e3566359941a",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = "test@test.com"
            };
        }
    }
}
