package com.example.larsnotedatabase.Models;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
@Table(name = "orchestral_set_instruments")
public class OrchestralSetInstrument {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Embeddable
    public class OrchestralSetInstrumentId implements Serializable {
        private int orchestralSetId;
        private int instrumentId;

        // Constructors, getters, setters, and other methods

        // Remember to override the `equals()` and `hashCode()` methods as well


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
}
