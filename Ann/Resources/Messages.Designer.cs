﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ann.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ann.Resources.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Activator type is not supported..
        /// </summary>
        internal static string ActivatorNotSupported {
            get {
                return ResourceManager.GetString("ActivatorNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of input values must be equal to a number of neurons in the Input Layer..
        /// </summary>
        internal static string InvalidInputArguments {
            get {
                return ResourceManager.GetString("InvalidInputArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid network configuration. Learning rate value must be between 0 and 1..
        /// </summary>
        internal static string InvalidLearningRate {
            get {
                return ResourceManager.GetString("InvalidLearningRate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid network configuration. Momentum value must be between 0 and 1..
        /// </summary>
        internal static string InvalidMomentum {
            get {
                return ResourceManager.GetString("InvalidMomentum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid network configuration. Network must have at least one Hidden Layer..
        /// </summary>
        internal static string InvalidNumberOfHiddenLayers {
            get {
                return ResourceManager.GetString("InvalidNumberOfHiddenLayers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid network configuration. Network must have one and only one Input Layer..
        /// </summary>
        internal static string InvalidNumberOfInputLayers {
            get {
                return ResourceManager.GetString("InvalidNumberOfInputLayers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid network configuration. Network must have one and only one Output Layer..
        /// </summary>
        internal static string InvalidNumberOfOutputLayers {
            get {
                return ResourceManager.GetString("InvalidNumberOfOutputLayers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of target values must be equal to a number of neurons in the Output Layer..
        /// </summary>
        internal static string InvalidTargetOutput {
            get {
                return ResourceManager.GetString("InvalidTargetOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Network configuration was not saved. Save the Network configuration before initiating the trainig process..
        /// </summary>
        internal static string NetworkNotSaved {
            get {
                return ResourceManager.GetString("NetworkNotSaved", resourceCulture);
            }
        }
    }
}
