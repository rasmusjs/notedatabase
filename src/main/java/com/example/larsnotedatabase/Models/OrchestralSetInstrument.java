import javax.persistence.*;

@Entity
@Table(name = "orchestral_set_instruments")
public class OrchestralSetInstrument {
    @EmbeddedId
    private OrchestralSetInstrumentId id;

    @ManyToOne
    @MapsId("orchestralSetId")
    @JoinColumn(name = "orchestral_set_id", nullable = false)
    private OrchestralSet orchestralSet;

    @ManyToOne
    @MapsId("instrumentId")
    @JoinColumn(name = "instrument_id", nullable = false)
    private Instrument instrument;

    // Constructors, Getters and Setters
    // ...

    // Other fields, constructors, getters, setters, and methods omitted for brevity
}
