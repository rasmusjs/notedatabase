export {};

declare global {
    // Interface to define the structure of a page object
    interface Page {
        to: string;
        title: string;
        icon: string;
    }
}