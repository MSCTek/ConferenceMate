// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace MSC.ConferenceMate.Repository.Entities.CM
{

    // AspNetUserLogins
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.33.0.0")]
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; } // LoginProvider (Primary key) (length: 128)
        public string ProviderKey { get; set; } // ProviderKey (Primary key) (length: 128)
        public string UserId { get; set; } // UserId (Primary key) (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent AspNetUser pointed by [AspNetUserLogins].([UserId]) (FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId)
        /// </summary>
        public AspNetUser AspNetUser { get; set; } // FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId

        public AspNetUserLogin()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
