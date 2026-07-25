import * as v from "valibot";

export const OrderFormSchema = v.object({
  email: v.pipe(
    v.string(),
    v.nonEmpty("Please enter your email"),
    v.email("The email address is invalid"),
  ),
  phoneNumber: v.pipe(v.string(), v.nonEmpty("Please enter a phonenumber")),
  socialSecurityNumber: v.pipe(v.string()),
  firstName: v.pipe(v.string()),
  lastName: v.pipe(v.string()),
  street: v.pipe(v.string()),
  postalCode: v.pipe(v.string()),
  city: v.pipe(v.string()),
  shippingMethod: v.object({
    identifier: v.pipe(v.string()),
    type: v.pipe(v.string()),
    price: v.pipe(v.number()),
    description: v.pipe(v.string()),
  }),
  paymentMethod: v.variant("type", [
    v.object({
      type: v.literal("card"),
      cardInfo: v.object({
        cardNumber: v.pipe(v.string(), v.creditCard()),
        expiryDate: v.pipe(
          v.string(),
          v.regex(
            /^(?:0[1-9]|1[0-2])\/(?:2[5-9]|3[0-9])$/,
            "The expiration date is badly formatted.",
          ),
        ),
        cvv: v.pipe(v.string()),
      }),
    }),
    v.object({
      type: v.literal("swish"),
      phoneNumber: v.pipe(
        v.string(),
        v.nonEmpty("Please enter a phone number"),
      ),
    }),
    v.object({
      type: v.literal("invoice"),
      socialSecurityNumber: v.pipe(
        v.string(),
        v.nonEmpty("Please enter a number"),
      ),
    }),
  ]),
});

export const LoginFormSchema = v.object({
  email: v.pipe(
    v.string(),
    v.trim(),
    v.nonEmpty("Please enter an email."),
    v.email("The email address is invalid"),
  ),
  password: v.pipe(
    v.string(),
    v.nonEmpty("Please enter a password."),
    v.minLength(12, "Your password must be at least 12 characters"),
  ),
});

export const RegisterFormSchema = v.pipe(
  v.object({
    email: v.pipe(
      v.string(),
      v.trim(),
      v.nonEmpty("Please enter an email."),
      v.email("The email address is invalid"),
    ),
    firstName: v.pipe(v.string(), v.nonEmpty("Please enter your first name")),
    lastName: v.pipe(v.string(), v.nonEmpty("Please enter your last name.")),
    password: v.pipe(
      v.string(),
      v.nonEmpty("Please enter a password."),
      v.minLength(12, "Your password must be at least 12 characters"),
      v.regex(
        /[A-Z]/,
        "Your password must contain at least one uppercase letter.",
      ),
      v.regex(
        /[a-z]/,
        "Your password must contain at least one lowercase letter.",
      ),
      v.regex(/[0-9]/, "Your password must contain at least one number."),
      v.regex(
        /[.*:]/,
        "Your password must contain at least one non alphanumeric symbol.",
      ),
    ),
    confirmPassword: v.string(),
  }),
  v.forward(
    v.partialCheck(
      [["password"], ["confirmPassword"]],
      (input) => input.password === input.confirmPassword,
      "Paswords do not match",
    ),
    ["confirmPassword"],
  ),
);
