import javax.persistence.*;
import java.time.LocalDate;

@Entity
@Table(name = "orchestral_sets")
public class OrchestralSet {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "name", nullable = false)
    private String name;

    @ManyToOne
    @JoinColumn(name = "creator_id", nullable = false)
    private User creator;

    @Column(name = "description")
    private String description;

    @ManyToOne
    @JoinColumn(name = "country_id")
    private Country country;

    @Column(name = "created_date", nullable = false)
    private LocalDate createdDate;

    @Column(name = "updated_date")
    private LocalDate updatedDate;

    // Constructors, Getters and Setters
    // ...

    // Other fields, constructors, getters, setters, and methods omitted for brevity
}
