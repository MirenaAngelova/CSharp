namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    /// <summary>
    /// An interface representing the aclass that carries information common for all races.
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// A property representing traveled from boats distance and return integer value.
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// A property characterizing the wind speed and return integer value.
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// A property characterizing the ocean current speed and return integer value.
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// A property characterizing the allows motor boats and return boolean value.
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// A method adds participants in race and return IBoat value.
        /// </summary>
        void AddParticipant(IBoat boat);

        /// <summary>
        /// A method gats participants in race and return IBoat value.
        /// </summary>
        IList<IBoat> GetParticipants();
    }
}
