namespace Models.Guns
{
    public interface IGunsFactoryConfig
    {
        float MachineGunFireDelay { get; }

        float MachineGunFireRange { get; }
    }
}