import { Component } from "solid-js";
import Modal from "./Modal";
import { CreateNewReviewModalProps } from "../Types/modal";
import { createForm, Field, Form, reset, SubmitHandler } from "@formisch/solid";
import { CreateReviewSchema } from "../Types/validation-schemas";
import { ReviewInput } from "../Types/User/review";
import TextInput from "./Input/TextInput";
import ScoreInput from "./Input/ScoreInput";

const ModalCreateNewReview: Component<CreateNewReviewModalProps> = (props) => {
  const newReviewForm = createForm({
    schema: CreateReviewSchema,
    initialInput: { score: 0, text: "" },
  });

  const handleSubmit: SubmitHandler<typeof CreateReviewSchema> = (values) => {
    if (props.bookId === 0) {
      throw Error("Bookd Id not found.");
    }
    const newReview: ReviewInput = {
      title: values.title,
      text: values.text,
      score: values.score,
      bookId: props.bookId,
    };
    props.createNewReview(newReview);
    reset(newReviewForm);
    props.onClose();
  };

  return (
    <Modal
      open={props.open}
      onClose={props.onClose}
      title={`Create new Review`}
    >
      <Form of={newReviewForm} onSubmit={handleSubmit}>
        <Field of={newReviewForm} path={["title"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="text"
              label="Title"
              placeholder="Enter a title"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={newReviewForm} path={["text"]}>
          {(field) => (
            <div>
              <label
                class="block mb-3 overflow-hidden px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3"
                for="review"
              >
                <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                  Review <span class="text-everforest-red">*</span>
                </span>
                <textarea
                  class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                  {...field.props}
                  id="review"
                  rows={4}
                  placeholder="What did you think about the book?"
                  required
                />
              </label>
              {field.errors && (
                <span class=" text-everforest-red">{field.errors}</span>
              )}
            </div>
          )}
        </Field>
        <Field of={newReviewForm} path={["score"]}>
          {(field) => (
            <ScoreInput
              {...field.props}
              label="Rating Select"
              value={field.input ?? 0}
              errors={field.errors}
              onChange={field.onInput}
            />
          )}
        </Field>
        <div class=" flex flex-row items-center justify-center gap-1">
          <button
            type="submit"
            disabled={props.loading}
            class="w-full bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-1 focus:ring-everforest-aqua focus:ring-offset-2"
          >
            {props.loading ? "Leaving review..." : "Leave review"}
          </button>
          <button
            type="button"
            onClick={props.onClose}
            class="w-full bg-everforest-red py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-1 focus:ring-everforest-aqua focus:ring-offset-2"
          >
            Cancel
          </button>
        </div>
      </Form>
    </Modal>
  );
};

export default ModalCreateNewReview;
