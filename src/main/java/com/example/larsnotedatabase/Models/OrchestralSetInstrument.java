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

        @ManyToOne
        @MapsId("orchestralSetId")
        @JoinColumn(name = "orchestral_set_id", nullable = false)
        private OrchestralSet orchestralSet;

        @ManyToOne
        @MapsId("instrumentId")
        @JoinColumn(name = "instrument_id", nullable = false)
        private Instrument instrument;

        // Constructors
        public OrchestralSetInstrumentId(int orchestralSetId, int instrumentId, OrchestralSet orchestralSet, Instrument instrument) {
            this.orchestralSetId = orchestralSetId;
            this.instrumentId = instrumentId;
            this.orchestralSet = orchestralSet;
            this.instrument = instrument;
        }

        public OrchestralSetInstrumentId() {
        }

        // Getters and Setters
        public int getOrchestralSetId() {
            return orchestralSetId;
        }

        public void setOrchestralSetId(int orchestralSetId) {
            this.orchestralSetId = orchestralSetId;
        }

        public int getInstrumentId() {
            return instrumentId;
        }

        public void setInstrumentId(int instrumentId) {
            this.instrumentId = instrumentId;
        }

        public OrchestralSet getOrchestralSet() {
            return orchestralSet;
        }

        public void setOrchestralSet(OrchestralSet orchestralSet) {
            this.orchestralSet = orchestralSet;
        }

        public Instrument getInstrument() {
            return instrument;
        }

        public void setInstrument(Instrument instrument) {
            this.instrument = instrument;
        }
    }
}
