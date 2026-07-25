export const FormatDate = (dateString: string): string => {
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = date.getMonth();
  const day = date.getDate();
  return `${day}/${month}/${year}`;
};

export const ParseExpiryDate = (dateString: string): Date => {
  const split = dateString.split("/");
  const month = parseInt(split[0]);
  const year = parseInt(split[1]);

  const fullYear = 2000 + year;

  const date = new Date(fullYear, month, 0);
  return date;
};
