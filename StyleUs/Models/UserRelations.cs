using System;
namespace StyleUs.Models
{
    public enum UserRelations
    {
        NOTHING = 1,
        MUTUAL_FOLLOW = 2,
        FOLLOWS =  3,
        FOLLOWED_BY = 4,
        BLOCKS = 5,
        BLOCKED_BY = 6,
    }
}
