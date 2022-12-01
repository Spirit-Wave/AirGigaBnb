export interface IApartment {
  id?: string;
  dateCreated?: string;
  dateUpdated?: string;
  title?: string;
  apartmentType?: number;
  ownerId?: string;
  roomCount?: number;
  maxOccupancy?: number;
  bathroomCount?: number;
  bedroomCount?: number;
  city?: string;
  summary?: string;
  address?: string;
  hasTelevision?: boolean;
  hasKitchen?: boolean;
  hasAirConditioner?: boolean;
  hasInternet?: boolean;
  price?: number;
  datePublished?: string;
  listingState?: number;
  owner?: [
    id?: string,
    dateCreated?: string,
    dateUpdated?: string,
    name?: string,
    email?: string,
    password?: string,
    phoneNumber?: string,
    description?: string,
    role?: string
  ];
}
